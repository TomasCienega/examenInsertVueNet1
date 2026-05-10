import api from './api'

export default {
  async getEmpleados(idDep = 0) {
    try {
      const response = await api.get(`/Empleado/ListaEmpleados?idDep=${idDep}`)
      return response.data
    } catch (error) {
      console.error('Error fetching Empleados:', error)
      throw error
    }
  },
  async guardarEmpleado(data) {
    try {
      const response = await api.post('/Empleado/GuardarEmpleado', data)
      return response.data
    } catch (error) {
      console.error('Error guardando Empleado:', error)
      throw error
    }
  },
}
