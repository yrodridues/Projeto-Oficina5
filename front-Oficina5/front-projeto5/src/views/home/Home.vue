<template>
  <v-img
    src="../img/background.jpg"
    gradient="to top right, rgba(100,150,250,.6), rgba(250,150,100,.6)"
    class="grey lighten-2">
    <v-container
      fill-height
      fluid
      grid-list-xl
      text-xs-center>
      <v-layout
        row
        wrap>
        <v-flex
          xl12
          lg12
          md12
          sm12
          xs11>
          <v-card
            dark
            color="blue accent-4">
            <v-card-text>
              <div
                class="subtitle-1"
                style="color: white; text-align: center;">
                Bem Vindo(a)!
              </div>
              <v-spacer/>
              <div
                class="subtitle-2"
                style="color: white; text-align: center;">
                {{ nomeUsuario }}
              </div>
            </v-card-text>
          </v-card>
          <v-parallax
            height="450"
            src="../img/Wallpaper.jpg"/>
        </v-flex>
      </v-layout>
    </v-container>
  </v-img>
</template>

<script>
import { mapState, mapActions } from 'vuex'

export default {
  data () {
    return {
      isMobile: false,
      valid: true,
      nomeUsuario: '',
      idUsuario: '',
      show: false,
      flat: false,
      media: true,
      loading: false,
      actions: true,
      outlined: false,
      elevation: undefined,
      raised: false,
      width: 344,
      height: undefined
    }
  },
  computed: {
    ...mapState({
      account: state => state.account
    }),
    imageHeight () {
      switch (this.$vuetify.breakpoint.name) {
        case 'xs': return '220px'
        case 'sm': return '400px'
        case 'md': return '500px'
        case 'lg': return '600px'
        case 'xl': return '800px'
      }
    }
  },
  mounted () {
    console.log(this.$vuetify.breakpoint)
    this.onResize()
    window.addEventListener('resize', this.onResize, { passive: true })
  },
  beforeDestroy () {
    if (typeof window !== 'undefined') {
      window.removeEventListener('resize', this.onResize, { passive: true })
    }
  },
  created () {
    this.NomeDoUsuario()
  },

  methods: {
    ...mapActions('pessoas', {
      getAllPessoas: 'getAll'
    }),
    onResize () {
      this.isMobile = window.innerWidth < 600
    },
    NomeDoUsuario () {
      if (this.account !== null || this.account.user !== null || this.account !== '' || this.account.user !== '') {
        this.account.user = JSON.parse(localStorage.getItem('usuario'))
        this.nomeUsuario = this.account.user.value.nome
      }
    }
  }
}
</script>

<style scoped>
.bg1 {
    background: url('https://i.pinimg.com/originals/09/64/25/09642539eb8b3ab544b2f33848b0c67a.jpg');
    background-size: cover;
  }
</style>
