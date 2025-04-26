import axios from 'axios';

// Địa chỉ API Brand
const API_URL = 'http://localhost:5085/api/Brand'; // Đổi thành API thực tế của bạn

// Hàm lấy tất cả thương hiệu
export const getBrands = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data; // Dữ liệu thương hiệu trả về
  } catch (error) {
    console.error('Error fetching brands:', error);
    throw new Error('Failed to fetch brands');
  }
};