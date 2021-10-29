<template>
  <div class="container">
    <div class="row mt-4">
      <div class="col d-flex justify-content-center">
        <div class="card" style="width: 18rem">
          <img
            class="mx-auto d-block img-fluid card-img-top"
            src="@/assets/logo.png"
            width="150"
            height="100"
            alt=""
          />
          <div class="card-body">
            <h5 class="card-title">Login</h5>
            <form>
              <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Email</label>
                <input
                  type="email"
                  class="form-control"
                  id="exampleInputEmail1"
                  aria-describedby="emailHelp"
                />
              </div>
              <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label"
                  >Password</label
                >
                <input
                  type="password"
                  class="form-control"
                  id="exampleInputPassword1"
                />
              </div>
              <router-link :to="{name: 'Home'}" class="btn btn-login">
                INICIAR SESION
              </router-link>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Login",
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
.btn-action:hover,
.btn-login {
  background-color: #1b2b84;
  color: #fff;
}
.btn-login:hover {
  color: #fff;
  background-color: #111f63;
}
</style>