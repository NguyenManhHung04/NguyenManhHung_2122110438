import axios from 'axios';

// Địa chỉ API của bạn
const API_URL = 'http://localhost:5085/api/Product'; // Thay đổi thành URL backend của bạn

// Hàm lấy tất cả sản phẩm
export const getProducts = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data; // Dữ liệu trả về từ backend
  } catch (error) {
    console.error('Error fetching products:', error);
    throw new Error('Failed to fetch products');
  }
};
