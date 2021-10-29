import PersonaService from '@/services/PersonaService'

export default{
    state:{
        personas: [],
    },
    mutations: {
        setPersonas(state, personas){
            state.personas = personas;
        },
    },
    actions:{
        async GetPersonas({ commit }){
            const result = await PersonaService.GetPersonas();
            commit("setPersonas", result.data);
            return result;
        },

        async DeletePersona({ commit, dispatch }, id){
            const result = await PersonaService.DeletePersona(id);
            window.location.reload();
        }
    },
    getters:{
        personas(state){
            return state.personas;
        }
    }
}