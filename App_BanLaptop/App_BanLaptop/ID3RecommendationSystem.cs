using BLL;
using Common;
using DTO;
using DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BanLaptop
{
    public class ID3RecommendationSystem
    {
        private readonly DatHangBLL datHangBLL;
        private readonly LaptopBLL laptopBLL;

        public ID3RecommendationSystem()
        {
            datHangBLL = new DatHangBLL();
            laptopBLL = new LaptopBLL();
        }

        public List<Laptop> GetRecommendations(int userId, List<Laptop> purchaseHistory, int numberOfRecommendations)
        {
            try
            {
                // Nếu không có lịch sử mua hàng
                if (!purchaseHistory.Any())
                {
                    return GetBestSellingLaptops(numberOfRecommendations);
                }

                // Xây dựng cây quyết định từ lịch sử mua hàng
                var tree = BuildDecisionTree(purchaseHistory);
                
                // Tìm các sản phẩm tương tự
                return FindSimilarLaptops(tree, purchaseHistory, numberOfRecommendations);
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, trả về danh sách sản phẩm bán chạy
                return GetBestSellingLaptops(numberOfRecommendations);
            }
        }
        private List<Laptop> GetBestSellingLaptops(int count)
        {
            try
            {
                return laptopBLL.GetLaptop()
                            .OrderByDescending(l => l.SoLuongTon)
                            .Take(count)
                            .ToList();
            }
            catch
            {
                return new List<Laptop>();
            }
        }
        private List<Laptop> FindSimilarLaptops(DecisionTreeNode tree, List<Laptop> userHistory, int count)
        {
            try
            {
                var allProducts = laptopBLL.GetLaptop();
                var scoredProducts = new Dictionary<Laptop, double>();

                foreach (var product in allProducts)
                {
                    // Bỏ qua sản phẩm đã có trong lịch sử mua
                    if (!userHistory.Any(h => h.MaLap == product.MaLap))
                    {
                        double score = CalculateSimilarityScore(tree, product, userHistory);
                        scoredProducts[product] = score;
                    }
                }

                return scoredProducts
                    .OrderByDescending(x => x.Value)
                    .Take(count)
                    .Select(x => x.Key)
                    .ToList();
            }
            catch
            {
                return GetBestSellingLaptops(count);
            }
        }

        private double CalculateSimilarityScore(DecisionTreeNode tree, Laptop product, List<Laptop> userHistory)
        {
            double score = 0;
            var attributes = new Dictionary<string, string>
            {
                { "MAHANG", product.MaHang.ToString() },
                { "MANSX", product.MaNSX.ToString() },
                { "PRICE_RANGE", GetPriceRange(product.GiaBan) }
            };

            // Tính điểm dựa trên cây quyết định
            var node = tree;
            while (node.Children.Any())
            {
                var attribute = node.SplitAttribute;
                var value = attributes[attribute];
                
                if (node.Children.ContainsKey(value))
                {
                    node = node.Children[value];
                    score += 1.0;
                }
                else
                    break;
            }

            // Thêm điểm cho các thuộc tính phổ biến
            if (userHistory.Any(h => h.MaHang == product.MaHang))
                score += 2.0;
            if (userHistory.Any(h => h.MaNSX == product.MaNSX))
                score += 1.5;
            if (userHistory.Any(h => GetPriceRange(h.GiaBan) == GetPriceRange(product.GiaBan)))
                score += 1.0;

            return score;
        }
        private DecisionTreeNode BuildDecisionTree(List<Laptop> trainingData)
        {
            var attributes = new List<string> { "MAHANG", "MANSX", "PRICE_RANGE" };
            return BuildTreeRecursive(trainingData, attributes, trainingData);
        }

        private DecisionTreeNode BuildTreeRecursive(List<Laptop> data, List<string> attributes, List<Laptop> parentData)
        {
            var node = new DecisionTreeNode();

            // Điều kiện dừng
            if (!data.Any() || !attributes.Any())
            {
                node.Prediction = GetMostCommonLaptop(parentData).MaLap.ToString();
                return node;
            }

            // Tìm thuộc tính tốt nhất để phân chia
            var bestAttribute = CalculateBestAttribute(data, attributes);
            node.SplitAttribute = bestAttribute;

            // Phân chia dữ liệu theo thuộc tính
            var attributeValues = GetAttributeValues(data, bestAttribute);
            var remainingAttributes = attributes.Where(a => a != bestAttribute).ToList();

            foreach (var value in attributeValues)
            {
                var subset = GetSubset(data, bestAttribute, value);
                node.Children[value] = BuildTreeRecursive(subset, remainingAttributes, data);
            }

            return node;
        }

        // Thêm các phương thức hỗ trợ
        private Laptop GetMostCommonLaptop(List<Laptop> data)
        {
            return data.GroupBy(l => l.MaLap)
                      .OrderByDescending(g => g.Count())
                      .First()
                      .First();
        }

        private string CalculateBestAttribute(List<Laptop> data, List<string> attributes)
        {
            double maxGain = double.MinValue;
            string bestAttribute = null;

            double initialEntropy = CalculateEntropy(data);

            foreach (var attribute in attributes)
            {
                double gain = CalculateInformationGain(data, attribute, initialEntropy);
                if (gain > maxGain)
                {
                    maxGain = gain;
                    bestAttribute = attribute;
                }
            }

            return bestAttribute;
        }

        private double CalculateEntropy(List<Laptop> data)
        {
            var categoryGroups = data.GroupBy(l => l.MaLap);
            double entropy = 0;
            int totalCount = data.Count;

            foreach (var group in categoryGroups)
            {
                double probability = (double)group.Count() / totalCount;
                // Sử dụng Math.Log với cơ số e và chuyển sang cơ số 2
                entropy -= probability * (Math.Log(probability) / Math.Log(2));
            }

            return entropy;
        }

        private double CalculateInformationGain(List<Laptop> data, string attribute, double parentEntropy)
        {
            var attributeValues = GetAttributeValues(data, attribute);
            double weightedEntropy = 0;
            int totalCount = data.Count;

            foreach (var value in attributeValues)
            {
                var subset = GetSubset(data, attribute, value);
                double probability = (double)subset.Count / totalCount;
                weightedEntropy += probability * CalculateEntropy(subset);
            }

            return parentEntropy - weightedEntropy;
        }

        private List<string> GetAttributeValues(List<Laptop> data, string attribute)
        {
            switch (attribute)
            {
                case "MAHANG":
                    return data.Select(l => l.MaHang.ToString()).Distinct().ToList();
                case "MANSX":
                    return data.Select(l => l.MaNSX.ToString()).Distinct().ToList();
                case "PRICE_RANGE":
                    return data.Select(l => GetPriceRange(l.GiaBan)).Distinct().ToList();
                default:
                    return new List<string>();
            }
        }

        private List<Laptop> GetSubset(List<Laptop> data, string attribute, string value)
        {
            switch (attribute)
            {
                case "MAHANG":
                    return data.Where(l => l.MaHang.ToString() == value).ToList();
                case "MANSX":
                    return data.Where(l => l.MaNSX.ToString() == value).ToList();
                case "PRICE_RANGE":
                    return data.Where(l => GetPriceRange(l.GiaBan) == value).ToList();
                default:
                    return new List<Laptop>();
            }
        }

        private string GetPriceRange(decimal price)
        {
            if (price < 15000000) return "LOW";
            if (price < 25000000) return "MEDIUM";
            return "HIGH";
        }
    }
}
