<template>
  <v-navigation-drawer
    id="app-drawer"
    v-model="inputValue"
    app
    light
    floating
    persistent
    mobile-break-point="991"
    width="260">
    <v-layout
      class="fill-height"
      tag="v-list"
      column>
      <v-list-tile
        avatar
        class="logo">
        <v-list-tile-avatar
          size="70"
          style="margin:auto; display: block">
          <v-img
            :src="logo"
            height="85"
            style="margin: auto; display: block"
            contain/>
        </v-list-tile-avatar>
      </v-list-tile>
      <v-list-tile>
        <div class="posicionamentoExterno">
          <v-list class="posicionamentoInterno">Projeto Oficina5</v-list>
        </div>
      </v-list-tile>
      <v-divider/>
      <div
        v-for="(link, i) in links"
        :key="i">
        <v-list-tile
          :to="link.to"
          :active-class="color"
          avatar
          class="v-list-item">
          <v-list-tile-action>
            <v-icon>{{ link.icon }}</v-icon>
          </v-list-tile-action>
          <v-list-tile-title v-text="link.text" />
        </v-list-tile>
        <div v-show="link.divider == true">
          <v-divider />
        </div>
      </div>
    </v-layout>
  </v-navigation-drawer>
</template>

<script>

import { mapMutations, mapState } from 'vuex'

export default {
  data: () => ({
    perfil: '',
    logo: './img/logoVue.png',
    links: [
      {
        to: '/',
        icon: 'mdi-monitor',
        text: 'Home',
        divider: true
      },
      {
        to: '/pagina1',
        icon: 'mdi-monitor',
        text: 'Pagina APIs Usuarios'
      },
      {
        to: '/pagina2',
        icon: 'mdi-monitor',
        text: 'Pagina APIs Mensagens'
      }
    ],
    responsive: false
  }),
  computed: {
    ...mapState('app', ['color']),
    inputValue: {
      get () {
        return this.$store.state.app.drawer
      },
      set (val) {
        this.setDrawer(val)
      }
    },
    items () {
      return this.$t('Layout.View.items')
    },
    ...mapState({
      account: state => state.account
    })
  },
  created () {
    this.getUsuarioStorage()
    if (!this.usuario.perfilSuper) {
      this.validaPerfil()
    }
  },
  mounted () {
    this.onResponsiveInverted()
    window.addEventListener('resize', this.onResponsiveInverted)
  },
  beforeDestroy () {
    window.removeEventListener('resize', this.onResponsiveInverted)
  },
  methods: {
    ...mapMutations('app', ['setDrawer', 'toggleDrawer']),
    onResponsiveInverted () {
      if (window.innerWidth < 991) {
        this.responsive = true
      } else {
        this.responsive = false
      }
    },
    getUsuarioStorage () {
      let usuario = JSON.parse(localStorage.getItem('usuario'))
      this.usuario = usuario.value
    },
    validaPerfil () {
      let ids = []
      for (let i = 0; i < this.links.length; i++) {
        if (!this.links[i].title && this.links[i].text !== 'Sair') {
          if (!this.verificarSeExiste(this.links[i].text)) {
            ids.push(i)
          }
        }
      }
      this.remontaMenu(ids)
    },
    verificarSeExiste (item) {
      let existe = false
      for (let i = 0; i < this.usuario.moduloDescricaoFuncao.length; i++) {
        if (this.usuario.moduloDescricaoFuncao[i].descricaoModulo === item) {
          existe = true
          break
        } else {
          existe = false
        }
      }
      return existe
    },
    remontaMenu (ids) {
      let menuAntigo = this.links
      this.links = []
      for (let i = 0; i < menuAntigo.length; i++) {
        if (this.verificaRecriaMenu(i, ids)) {
          this.links.push(menuAntigo[i])
        }
      }
    },
    verificaRecriaMenu (item, ids) {
      for (let i = 0; i < ids.length; i++) {
        if (item === ids[i]) {
          return false
        }
      }
      return true
    }
  }
}
</script>
<style scoped>
/* .theme--light.v-list{
 color: #fff
}
.theme--light.v-list-item:not(.v-list-item--active):not(.v-list-item--disabled){
 color: #fff !important
} */
</style>
