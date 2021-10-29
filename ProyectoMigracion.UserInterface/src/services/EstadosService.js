import Service from './Service';
import axios from 'axios';

const API_URL = 'https://localhost:44369/api';
const ENDPOINT = 'Estados';

class EstadosService {

    async GetEstados(){
        const request = await axios(`${API_URL}/${ENDPOINT}`);
        return request;
    }

    async GetEstado(id){
        const request = await axios(`${API_URL}/${ENDPOINT}`);
    }


}   

export default new EstadosService();