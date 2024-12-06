import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    searchResults: [],
    noResultsFound: false,  // Thêm thuộc tính noResultsFound
    loading: false,
    error: null
  };
  
  const searchSlice = createSlice({
    name: 'search',
    initialState,
    reducers: {
      setSearchResults: (state, action) => {
        //console.log("Payload data:", action.payload);
        state.loading = false;
        state.searchResults = action.payload;
        state.noResultsFound = action.payload.length === 0;  // Cập nhật trạng thái noResultsFound khi search k tìm thấy KQ
      },
      setLoading: (state) => {
        state.loading = true;
      },
      setError: (state, action) => {
        state.loading = false;
        state.error = action.payload;
      }
    }
  });
  

export const { setSearchResults, setLoading, setError } = searchSlice.actions;
export default searchSlice.reducer;
