// src/api/testConnection.ts
import { getProducts } from './productService';

const testApiConnection = async () => {
  try {
    console.log('Testing API connection...');
    const products = await getProducts();
    console.log('API connection successful!', products);
    return true;
  } catch (error) {
    console.error('API connection failed:', error);
    return false;
  }
};

export default testApiConnection;