<template>
  <header>
    <nav class="navbar navbar-expand-lg">
      <div class="container-fluid">
        <router-link class="navbar-brand" :to="{ name: 'Home' }">
          <img
            src="@/assets/logo.png"
            alt=""
            width="80"
            height="74"
            class="d-inline-block align-text-center"
          />
          Proyecto Migracion
          <br />
        </router-link>
        <button
          class="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
                <router-link class="nav-link" :to="{ name: 'Personas' }">Personas</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" :to="{ name: 'Solicitudes' }">Solicitudes</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" :to="{ name: 'Estados' }">Estados</router-link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </header>
</template>

<script>
export default {
  name: "Header",
};
</script>

<style lang="css" scoped>
.navbar {
  background-color: #eff4ff;
}
.navbar-brand,
.nav-link {
  color: #1b2b84;
  text-transform: uppercase;
}
</style>