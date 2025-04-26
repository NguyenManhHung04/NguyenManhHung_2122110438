import axios from 'axios';

// Địa chỉ API Category
const API_URL = 'http://localhost:5085/api/Category'; // Đổi thành API thực tế của bạn nhé

// Hàm lấy tất cả danh mục
export const getCategories = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data; // Dữ liệu danh mục trả về
  } catch (error) {
    console.error('Error fetching categories:', error);
    throw new Error('Failed to fetch categories');
  }
};
