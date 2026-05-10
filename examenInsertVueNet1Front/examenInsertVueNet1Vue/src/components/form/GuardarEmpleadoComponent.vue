<template>
  <div class="container mt-4">
    <div class="row justify-content-start">
      <div class="col-md-5">
        <form class="card shadow-lg" @submit.prevent="enviarFormulario">
          <div>
            <div class="card-header"><h3 class="card-title">Ingresar Usuario</h3></div>
            <div class="card-body">
              <div>
                <label class="form-label me-1">Nombre Empleado:</label>
                <input
                  type="text"
                  class="form-control-sm"
                  v-model="nuevoEmpleado.nombreEmpleado"
                  required
                />
              </div>
              <div>
                <label class="form-label me-1">Nombre Departamento:</label>
                <select class="form-select-sm" v-model="nuevoEmpleado.idDepartamento" required>
                  <option value="0" disabled>--Selecciona un departamento--</option>
                  <option
                    v-for="deps in props.departamentos"
                    :key="deps.idDepartamento"
                    :value="deps.idDepartamento"
                  >
                    {{ deps.nombreDepartamento }}
                  </option>
                </select>
              </div>
              <div>
                <button type="submit" class="btn btn-outline-secondary">Guardar</button>
              </div>
            </div>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>
<script setup>
import { useSwal } from '@/composables/useSwal'
import { reactive } from 'vue'
import empleadoService from '@/services/empleadoService'
const props = defineProps(['departamentos'])
const emit = defineEmits(['actualizar'])
const { showSuccess, showError } = useSwal()

const nuevoEmpleado = reactive({
  nombreEmpleado: '',
  idDepartamento: 0,
})

const enviarFormulario = async () => {
  try {
    //TODO: debugger
    await empleadoService.guardarEmpleado(nuevoEmpleado)

    await showSuccess('Empleado guardado')

    nuevoEmpleado.nombreEmpleado = ''
    nuevoEmpleado.idDepartamento = 0
    emit('actualizar')
  } catch (error) {
    showError('Error al guardar')
    console.error(error)
  }
}
</script>
<style scoped></style>
