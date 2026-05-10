<template>
  <GuardarEmpleadoComponent :departamentos="listDepartamentos" @actualizar="fetchEmpleados" />
  <EmpleadoTableandFilter
    :empleados="listEmpleados"
    :departamentos="listDepartamentos"
    @filtrar="fetchEmpleados"
  />
</template>
<script setup>
import { onMounted, reactive } from 'vue'
import empleadoService from '@/services/empleadoService'
import departamentoService from '@/services/departamentoService'
import GuardarEmpleadoComponent from '@/components/form/GuardarEmpleadoComponent.vue'
import EmpleadoTableandFilter from '@/components/body/EmpleadoTableandFilter.vue'
const listEmpleados = reactive([])
const listDepartamentos = reactive([])

const fetchEmpleados = async (idDep = 0) => {
  try {
    var result = await empleadoService.getEmpleados(idDep)
    listEmpleados.length = 0
    listEmpleados.push(...result)
    console.log(result)
  } catch (error) {
    console.log('Error Fetch Lista Empledos', error)
  }
}
const fetchDepartamentos = async () => {
  try {
    var result = await departamentoService.getDepartamentos()
    listDepartamentos.length = 0
    listDepartamentos.push(...result)
    console.log(result)
  } catch (error) {
    console.log('Error Fetch Lista Departamentos', error)
  }
}
onMounted(async () => {
  await fetchEmpleados()
  await fetchDepartamentos()
})
</script>
<style scoped></style>
