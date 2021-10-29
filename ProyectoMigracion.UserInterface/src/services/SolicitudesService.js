import Service from './Service';
import axios from 'axios';

const API_URL = 'https://localhost:44369/api';
const ENDPOINT = 'Solicitudes';

class SolicitudesService {

    async GetSolicitudes(){
        const request = await axios(`${API_URL}/${ENDPOINT}`);
        return request;
    }

    async GetSolicitud(id){
        const request = await axios(`${API_URL}/${ENDPOINT}`);
    }

    async DeleteSolicitud(id){
        const request = await axios.delete(`${API_URL}/${ENDPOINT}/${id}`);
        return request;
    }


}   

export default new SolicitudesService();