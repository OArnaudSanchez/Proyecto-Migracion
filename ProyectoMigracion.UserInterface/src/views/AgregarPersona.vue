<template>
    <div>
        <Header />
        <div class="container">
            <div class="row">
                <div class="col">
                <h1>Agregar Persona</h1>
                <form class="row">
                    <div class="mb-3 col-4">
                        <label class="form-label">Nombre</label>
                        <input
                        type="text"
                        class="form-control"
                        required
                        aria-describedby="emailHelp"
                        />
                    </div>
                    <div class="mb-3 col-4">
                        <label class="form-label"
                        >Apellidos</label
                        >
                        <input
                        type="text"
                        required
                        class="form-control"
                        />
                    </div>
                     <div class="mb-3 col-4">
                        <label class="form-label">Email</label>
                        <input
                        type="email"
                        class="form-control"
                        required
                        aria-describedby="emailHelp"
                        />
                    </div>
                     <div class="mb-3 col-4">
                        <label class="form-label">Fecha Nacimento</label>
                        <input
                        type="date"
                        class="form-control"
                        required
                        aria-describedby="emailHelp"
                        />
                    </div>
                     <div class="mb-3 col-4">
                        <label class="form-label">Direccion</label>
                        <input
                        type="text"
                        class="form-control"
                        required
                        aria-describedby="emailHelp"
                        />
                    </div>
                     <div class="mb-3 col-4">
                        <label class="form-label">Sexo</label>
                        <input type="radio" value="M"> Masculino
                        <input type="radio" value="F"> Femenino
                    </div>
                     <div class="mb-3 col-4">
                        <label class="form-label">Foto</label>
                        <input
                        type="file"
                        class="form-control"
                        required
                        aria-describedby="emailHelp"
                        />
                    </div>
                    <button class="btn btn-add">Guardar</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Header from '@/components/Header.vue';
    export default {
        name: 'AgregarPersona',
        components: {
            Header
        }
    }
</script>

<style lang="css" scoped>
.btn-add {
  background-color: #1b2b84;
  color: #fff;
}
.btn-add:hover {
  color: #fff;
  background-color: #111f63;
}
</style>