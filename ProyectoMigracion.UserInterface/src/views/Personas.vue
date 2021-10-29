<template>
  <div>
    <Header />
    <div class="container mt-5">
      <h2 class="text-center">Mantenimiento Personas</h2>
      <div class="row">
        <div class="col">
          <router-link :to="{ name: 'AgregarPersona' }" class="btn btn-action">Agregar Personas</router-link>
        </div>
      </div>
      <div class="row">
        <div class="col">
          <div class="table-responsive">
            <table class="table">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Nombre</th>
                  <th>Apellidos</th>
                  <th>Fecha Nacimiento</th>
                  <th>Pasaporte</th>
                  <th>Direccion</th>
                  <th>Sexo</th>
                  <th>Foto</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="persona in personas" :key="persona.id">
                  <td>{{ persona.id }}</td>
                  <td>{{ persona.nombre }}</td>
                  <td>{{ persona.apellido }}</td>
                  <td>{{ persona.fechaNacimiento }}</td>
                  <td>{{ persona.pasaporte }}</td>
                  <td>{{ persona.direccion }}</td>
                  <td>{{ persona.sexo }}</td>
                  <td>
                    <img
                      :src="persona.foto"
                      width="60"
                      height="auto"
                      alt=""
                    />
                  </td>
                  <td>
                    <router-link class="btn btn-action m-1" :to="{ name: 'EditPersona', params: { id: persona.id } }">
                      <i class="fas fa-edit"></i>
                    </router-link>
                    <button class="btn btn-action" @click="DeletePersona(persona)">
                      <i class="fas fa-trash-alt"></i>
                    </button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Header from "@/components/Header.vue";

export default {
  name: "Personas",
  components: {
    Header,
  },
  async created() {
    await this.fetchData();
  },
  methods: {
    async fetchData() {
      await this.$store.dispatch("GetPersonas");
    },
    async DeletePersona({ id }){
      if(confirm("Desea eliminar esta persona")){
        await this.$store.dispatch("DeletePersona", id);
      }
    }
  },
  computed: {
    personas() {
      return this.$store.getters.personas;
    },
  },
};
</script>

<style lang="css" scoped>
.btn-action {
  border-radius: 0.4em;
  padding: 0.5em 1.5em;
  background-color: transparent;
  border: 1px solid rgba(63, 81, 181, 0.5);
  color: #1b2b84;
  font-size: 0.875rem;
  font-weight: 500;
  line-height: 1.75;
  letter-spacing: 0.02857em;
  text-transform: uppercase;
}
.btn-action:hover {
  background-color: #1b2b84;
  color: #fff;
}
</style>