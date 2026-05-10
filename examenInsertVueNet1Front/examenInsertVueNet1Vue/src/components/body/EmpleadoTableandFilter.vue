<template>
  <div class="container mt-4">
    <div class="row justify-content-start">
      <div class="col-md-4">
        <div class="card shadow-sm">
          <div class="card-header"><h3>Filtro Departamento</h3></div>
          <div class="card-body">
            <select class="form-select-sm" @change="filtro">
              <option value="0">--Selecciona un departamento--</option>
              <option
                v-for="dep in props.departamentos"
                :key="dep.idDepartamento"
                :value="dep.idDepartamento"
              >
                {{ dep.nombreDepartamento }}
              </option>
            </select>
          </div>
        </div>
      </div>
      <div>
        <table class="table mt-3">
          <thead>
            <tr>
              <th>Id Empleado</th>
              <th>Nombre Empleado</th>
              <th>Departamento</th>
            </tr>
          </thead>
          <tbody v-if="props.empleados.length > 0">
            <tr v-for="emp in props.empleados" :key="emp.idEmpleado">
              <td>{{ emp.idEmpleado }}</td>
              <td>{{ emp.nombreEmpleado }}</td>
              <td>{{ emp.nombreDepartamento }}</td>
            </tr>
          </tbody>
          <tbody v-else>
            <tr>
              <td colspan="3" class="text-center">No hay empleados registrados.</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>
<script setup>
const props = defineProps(['empleados', 'departamentos'])
const emit = defineEmits(['filtrar'])
const filtro = (event) => {
  emit('filtrar', event.target.value)
}
</script>
<style scoped></style>
