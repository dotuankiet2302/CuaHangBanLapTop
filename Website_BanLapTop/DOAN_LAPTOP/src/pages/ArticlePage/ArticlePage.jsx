import React from "react";
import image1 from '../../assets/images/1.png';
import image2 from '../../assets/images/2.png';
import image3 from '../../assets/images/3.png';
import image4 from '../../assets/images/4.png';
import image5 from '../../assets/images/5.png';
import image6 from '../../assets/images/6.png';
import image7 from '../../assets/images/7.png';
import image8 from '../../assets/images/8.png';
import {
  WrapperContent,
  WrapperImageLeft,
  WrapperImageRight,
  WrapperImageCenter,
  WrapperImageList,
  Title,
  Paragraph,
} from "./style";

const ArticlePage = () => {
  return (
    <WrapperContent>
      {/* Tiêu đề bài viết */}
      <Title>Bài viết thú vị về công nghệ</Title>

      {/* Đoạn văn với hình ảnh bên trái */}
      <div style={{ display: "flex", alignItems: "center", marginBottom: "50px" }}>
        <WrapperImageLeft>
          <img src={image1} alt="Technology Left" />
        </WrapperImageLeft>
        <Paragraph>
          Công nghệ đang thay đổi thế giới từng ngày. Những tiến bộ về trí tuệ nhân tạo (AI) đang giúp cải thiện nhiều lĩnh vực, 
          từ y tế đến giáo dục và kinh doanh. AI không chỉ hỗ trợ con người giải quyết các vấn đề phức tạp mà còn nâng cao hiệu suất 
          làm việc, giúp tiết kiệm thời gian và tài nguyên. Blockchain, một đột phá quan trọng khác, đang thay đổi cách lưu trữ và bảo
           mật dữ liệu, đặc biệt trong tài chính và chuỗi cung ứng. Công nghệ không chỉ là công cụ, mà còn là nguồn cảm hứng để xây dựng 
           một tương lai tốt đẹp hơn.
        </Paragraph>
      </div>

      {/* Đoạn văn với hình ảnh bên phải */}
      <div style={{ display: "flex", alignItems: "center", justifyContent: "flex-end", marginBottom: "30px" }}>
        <Paragraph>
          Trong lĩnh vực công nghệ, Internet of Things (IoT) nổi lên như một xu hướng quan trọng. Các thiết bị thông minh như cảm biến, 
          máy điều hòa, và hệ thống chiếu sáng tự động đang kết nối với nhau, tạo thành một hệ sinh thái toàn diện. Điều này không chỉ
           giúp nâng cao chất lượng cuộc sống mà còn tối ưu hóa các nguồn tài nguyên, giảm thiểu lãng phí. IoT còn mang đến tiềm năng lớn 
           trong các ngành công nghiệp, giúp giám sát và tự động hóa quy trình sản xuất, từ đó tiết kiệm chi phí và tăng năng suất lao động.
        </Paragraph>
        <WrapperImageRight>
          <img src={image2} alt="Technology Right" />
        </WrapperImageRight>
      </div>

      {/* Đoạn văn với hình ảnh ở giữa */}
      <div style={{ textAlign: "center", marginBottom: "30px" }}>
        <WrapperImageCenter>
          <img src={image3} alt="Technology Center" />
        </WrapperImageCenter>
        <Paragraph>
          Công nghệ thực tế ảo (VR) và thực tế tăng cường (AR) đang dần thay đổi cách chúng ta tương tác với thế giới. Trong giáo dục,
           VR giúp học sinh và sinh viên trải nghiệm các bài học sống động như tham quan các địa điểm lịch sử hoặc thí nghiệm khoa học
            một cách an toàn. AR thì được ứng dụng rộng rãi trong bán lẻ, mang lại trải nghiệm mua sắm tiện lợi và trực quan hơn. Ngoài
             ra, cả hai công nghệ này đều mở ra cơ hội lớn trong lĩnh vực giải trí, từ game đến điện ảnh, khiến mọi thứ trở nên hấp dẫn
              hơn bao giờ hết.
        </Paragraph>
      </div>

      {/* Danh sách hình ảnh */}
      <h2 style={{ textAlign: "center",fontSize: "2rem",color: "#C15BFF", marginBottom: "20px" }}>Danh sách hình ảnh nổi bật</h2>
      <WrapperImageList>
        {[image6, image3, image5, image7, image8, image1].map((src, index) => (
          <img key={index} src={src} alt={`Image ${index + 1}`} />
        ))}
      </WrapperImageList>
    </WrapperContent>
  );
};

export default ArticlePage;
