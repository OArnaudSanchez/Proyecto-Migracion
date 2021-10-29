import EstadosService from '@/services/EstadosService';

export default{
    state:{
        estados: []
    },
    mutations: {
        setEstados(state, estados){
            state.estados = estados;
        }
    },
    actions:{
        async GetEstados({ commit }){
            const result = await EstadosService.GetEstados();
            commit("setEstados", result.data);
            return result;
        }
    },
    getters:{
        estados(state){
            return state.estados;
        }
    }
}