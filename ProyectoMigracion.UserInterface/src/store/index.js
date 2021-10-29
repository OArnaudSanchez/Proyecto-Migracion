import Vue from 'vue'
import Vuex from 'vuex'
import Personas from './modules/Persona.module';
import Solicitudes from './modules/Solicitudes.module';
import Estados from './modules/Estados.Module';

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
  },
  mutations: {
  },
  actions: {
  },
  modules: {
    Personas,
    Solicitudes,
    Estados
  }
})
