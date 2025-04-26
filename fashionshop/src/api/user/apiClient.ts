// src/api/apiClient.ts
import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'http://localhost:5085/api', // Đảm bảo đúng port API
  headers: {
    'Content-Type': 'application/json',
  },
});

export default apiClient;   