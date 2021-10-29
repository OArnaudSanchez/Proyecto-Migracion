<template>
  <div>
    <Header />
    <div class="container">
      <div class="row mt-4">
        <!-- Estas cards seran un componente -->
        <!-- Card de Personas -->
        <div class="col-md-6 col-lg-4 d-flex justify-content-center mb-3">
          <div class="card" style="width: 18rem">
            <img
              class="mx-auto d-block img-fluid mt-2 rounded-circle"
              src="@/assets/image.svg"
              width="100"
              height="100"
              alt="..."
            />
            <div class="card-body">
              <h2 class="card-title text-center">Personas</h2>
              <div class="d-grid gap-2">
                <router-link class="btn btn-action" :to="{ name: 'Personas' }">Personas</router-link>
              </div>
            </div>
          </div>
        </div>

        <!-- Card de solicitudes -->
        <div class="col-md-6 col-lg-4 d-flex justify-content-center mb-3">
          <div class="card" style="width: 18rem">
            <img
              class="mx-auto d-block img-fluid mt-2 rounded-circle"
              src="@/assets/image.svg"
              width="100"
              height="100"
              alt="..."
            />
            <div class="card-body">
              <h2 class="card-title text-center">Solicitudes</h2>
              <div class="d-grid gap-2">
                <router-link class="btn btn-action" :to="{ name: 'Solicitudes' }">Solicitudes</router-link>
              </div>
            </div>
          </div>
        </div>

        <!-- card de estados -->
        <div class="col d-flex justify-content-center mb-3">
          <div class="card" style="width: 18rem">
            <img
              class="mx-auto d-block img-fluid mt-2 rounded-circle"
              src="@/assets/image.svg"
              width="100"
              height="100"
              alt="..."
            />
            <div class="card-body">
              <h2 class="card-title text-center">Estados</h2>
              <div class="d-grid gap-2">
                <router-link class="btn btn-action" :to="{ name: 'Estados' }">Estados</router-link>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
export default {
  name: "Home",
  components: {
    Header,
  },
};
</script>

<style lang="css" scoped>
.card {
  padding: 1.5em 0.5em 0.5em;
  border-radius: 2em;
  text-align: center;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
  background-color: #eff4ff;
}
.card:hover {
  box-shadow: 1px 8px 20px darkgrey;
}
.card-title {
  /* font-weight: 700;
        font-size: 1.5em; */

  font-size: 1.5em;
  font-family: "Roboto", "Helvetica", "Arial", sans-serif;
  font-weight: 400;
  line-height: 1.04;
  letter-spacing: 0em;
}
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