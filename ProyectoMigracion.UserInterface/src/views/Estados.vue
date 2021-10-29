<template>
  <div>
    <Header />
    <div class="container mt-5">
      <h1 class="text-center">Estados</h1>
      <div class="row">
        <div class="col">
          <router-link :to="{ name: 'AgregarEstado' }" class="btn btn-action"
            >Agregar Estado</router-link
          >
        </div>
      </div>
      <div class="col">
        <ul v-for="estado in estados" :key="estado.nombreEstado">
          <li class="text-center mt-3">{{ estado.nombreEstado }}</li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
export default {
  name: "Estados",
  components: {
    Header,
  },
  async created() {
    await this.fetchData();
    console.log(this.estados);
  },
  methods: {
    async fetchData() {
      await this.$store.dispatch("GetEstados");
    },
    DeleteEstado({ id }) {
      console.log(id);
    },
  },
  computed: {
    estados() {
      return this.$store.getters.estados;
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