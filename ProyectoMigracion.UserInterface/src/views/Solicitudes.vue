<template>
  <div>
    <Header />
    <div class="container mt-5">
      <h1 class="text-center">Solicitudes</h1>
      <div class="row">
        <div class="col">
          <router-link :to="{ name: 'AgregarSolicitud' }" class="btn btn-action"
            >Agregar Solicitud</router-link
          >
        </div>
      </div>
      <div class="row">
        <div class="col">
          <div class="table-responsive">
            <table class="table">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Estado</th>
                  <th>Fecha</th>
                  <th>Persona ID</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="solicitud in solicitudes" :key="solicitud.id">
                  <td>{{ solicitud.id }}</td>
                  <td>{{ solicitud.nombreEstado }}</td>
                  <td>{{ solicitud.fechaCreacion }}</td>
                  <td>{{ solicitud.personaId }}</td>
                  <td>
                    <router-link
                      class="btn btn-action m-1"
                      :to="{
                        name: 'EditPersona',
                        params: { id: solicitud.id },
                      }"
                    >
                      <i class="fas fa-edit"></i>
                    </router-link>
                    <button class="btn btn-action">
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
  name: "Solicitudes",
  components: {
    Header,
  },
  async created() {
    await this.fetchData();
  },
  methods: {
    async fetchData() {
      await this.$store.dispatch("GetSolicitudes");
    },
    async DeleteSolicitud({ id }) {
      if (confirm("Desea eliminar esta persona")) {
        await this.$store.dispatch("DeleteSolicitud", id);
        window.location.reload();
      }
    },
  },
  computed: {
    solicitudes() {
      return this.$store.getters.solicitudes;
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