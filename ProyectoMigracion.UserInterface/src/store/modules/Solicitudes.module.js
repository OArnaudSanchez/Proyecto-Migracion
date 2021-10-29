import SolicitudesService from '@/services/SolicitudesService';

export default{
    state:{
        solicitudes: []
    },
    mutations: {
        setSolicitudes(state, solicitudes){
            state.solicitudes = solicitudes;
        }
    },
    actions:{
        async GetSolicitudes({ commit }){
            const result = await SolicitudesService.GetSolicitudes();
            commit("setSolicitudes", result.data);
            return result;
        },

        async DeleteSolicitud({ commit, dispatch }, id){
            const result = await SolicitudesService.DeleteSolicitud(id);
            return result;
        }
    },
    getters:{
        solicitudes(state){
            return state.solicitudes;
        }
    }
}