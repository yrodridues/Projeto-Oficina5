import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/home/Home'
import LoginPage from '../views/login/LoginPage'
import Pagina1 from '../views/pagina1/pagina1'
import Pagina2 from '../views/pagina1/pagina2'

Vue.use(Router)

export const router = new Router({
  mode: 'history',
  routes: [
    { path: '/', name: 'Home', component: Home },
    { path: '/login', component: LoginPage },
    { path: '/pagina1', component: Pagina1 },
    { path: '/pagina2', component: Pagina2 },
    { path: '*', redirect: '/' }
  ]
})

router.beforeEach((to, from, next) => {
  const publicPages = ['/login']
  const authRequired = !publicPages.includes(to.path)
  const loggedIn = localStorage.getItem('usuario')
  if (authRequired && !loggedIn) {
    return next('/login')
  }
  next()
})
