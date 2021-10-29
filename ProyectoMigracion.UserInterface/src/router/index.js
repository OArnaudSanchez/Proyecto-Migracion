import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Login',
    component: () => import('@/views/Login.vue')
  },
  {
    path: '/home',
    name: 'Home',
    component: () => import('@/views/Home.vue')
  },
  {
    path: '/personas',
    name: 'Personas',
    component: () => import('@/views/Personas.vue')
  },
  {
    path: '/agregarPersona',
    name: 'AgregarPersona',
    component: () => import('@/views/AgregarPersona.vue')
  },
  {
    path: '/personas/:id',
    name: 'EditPersona',
    component: () => import('@/views/EditPersona.vue')
  },
  {
    path: '/solicitudes',
    name: 'Solicitudes',
    component: () => import('@/views/Solicitudes.vue')
  },
  {
    path: '/agregarSolicitud',
    name: 'AgregarSolicitud',
    component: () => import('@/views/AgregarSolicitud.vue')
  },
  {
    path: '/estados',
    name: 'Estados',
    component: () => import('@/views/Estados.vue')
  },
  {
    path: '/agregarEstado',
    name: 'AgregarEstado',
    component: () => import('@/views/AgregarEstado.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
