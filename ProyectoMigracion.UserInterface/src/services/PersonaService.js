import Service from './Service';
import axios from 'axios';

const API_URL = 'https://localhost:44369/api';
const ENDPOINT = 'Personas';

class PersonaService {

    async GetPersonas(){
        const request = await axios(`${API_URL}/${ENDPOINT}`);
        return request;
    }

    async GetPersona(id){
        const request = await axios(`${API_URL}/${ENDPOINT}`);
        return request;
    }

    async DeletePersona(id){
        const request = await axios.delete(`${API_URL}/${ENDPOINT}/${id}`);
        return request;
    }

}   

export default new PersonaService();