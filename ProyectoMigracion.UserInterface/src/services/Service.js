import axios from 'axios';

const API_URL = `https://localhost:44369/api/`;
export default axios.create({
    baseUrl: API_URL
});