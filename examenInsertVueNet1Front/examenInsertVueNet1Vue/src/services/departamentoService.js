import api from './api'

export default {
  async getDepartamentos() {
    try {
      const response = await api.get('/Departamento/ListaDepartamentos')
      return response.data
    } catch (error) {
      console.error('Error fetching Deparamentos:', error)
      throw error
    }
  },
}
