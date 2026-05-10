import { createApp } from 'vue'
import { createPinia } from 'pinia'

// Importamos el CSS de Bootstrap
import 'bootstrap/dist/css/bootstrap.min.css'
// Importamos los Iconos de Bootstrap
import 'bootstrap-icons/font/bootstrap-icons.css'
// Importamos el JS de Bootstrap (para que funcionen modales, dropdowns, etc.)
import 'bootstrap/dist/js/bootstrap.bundle.min.js'
//npm para instalar bootstrap
// npm install bootstrap bootstrap-icons @popperjs/core

import App from './App.vue'

const app = createApp(App)

app.use(createPinia())

app.mount('#app')
