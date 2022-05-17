import Vue from 'vue'
import './plugins/fontawesome'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import store from './store'

import VueI18n from 'vue-i18n'

Vue.use(VueI18n)

import { messages, defaultLang } from "@/i18n";

const i18n = new VueI18n({
  messages,
  locale: defaultLang,
  fallbackLocale: defaultLang
});

Vue.use(require('vue-moment'))

Vue.config.productionTip = false

new Vue({
  router,
  store,
  i18n,
  render: h => h(App)
}).$mount('#app')
