import Vue from 'vue'
import App from './App.vue'
import router from './router'

Vue.config.productionTip = false

// Khai báo event bus
const EventBus = new Vue()
export default EventBus

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
