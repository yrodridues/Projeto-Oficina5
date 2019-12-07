import Vue from 'vue'

// Components
import './components'

// Plugins
import './plugins'

// Sync router with store
import { sync } from 'vuex-router-sync'

// Application imports
import App from './App'
import { router } from './_helpers'
import store from '@/_store'
import MultiFiltersPlugin from './plugins/MultiFilters'
import moment from 'moment'
// import { store } from './_store'

// Sync store with router
sync(store, router)
Vue.use(require('vue-moment'))
Vue.use(MultiFiltersPlugin)
moment.locale('pt')

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
