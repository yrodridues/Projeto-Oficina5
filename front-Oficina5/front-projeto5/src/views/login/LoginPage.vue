<template>
  <v-img
    src="../img/background.jpg"
    gradient="to top right, rgba(100,150,250,.6), rgba(250,150,100,.6)"
    class="grey lighten-2">
    <v-container
      grid-list-xl
      text-xs-center>
      <v-layout
        row
        wrap>
        <v-flex
          xs10
          sm5
          md4
          lg4
          xl4
          offset-sm4>
          <v-card
            elevation-24
            style="padding: 10px; border: 1px; border-radius: 50px;"
            class="caixaLogin">
            <v-card-text >
              <v-img
                :src="logo"
                height="100"
                contain/>
              <v-list-tile>
                <v-list-tile-title style="text-align: center">Projeto Oficina5</v-list-tile-title>
              </v-list-tile>
              <v-form
                ref="form"
                v-model="valid"
                lazy-validation>
                <v-text-field
                  v-model="email"
                  :rules="emailRules"
                  clearable
                  label="Login"
                  type="text"
                  color="primary"
                  required/>
                <v-text-field
                  v-model="senha"
                  :rules="senhaRules"
                  clearable
                  label="Senha"
                  type="password"
                  color="primary"
                  required/>
              </v-form>
              <v-btn
                :disabled="!valid"
                color="primary"
                @click="validate">Entrar</v-btn>
            </v-card-text>
          </v-card>
        </v-flex>
      </v-layout>
      <div v-if="account.state.mensagem == 'Error'">
        <v-flex
          xs12
          sm5
          md4
          offset-sm4>
          <v-alert
            :value="true"
            type="error">
            Login ou senha inválidos.
          </v-alert>
        </v-flex>
      </div>
    </v-container>
  </v-img>
</template>
<script>
import { mapState, mapActions } from 'vuex'
export default {
  data () {
    return {
      el: '#app',
      logo: './img/logoVue.png',
      email: '',
      emailRules: [
        v => !!v || 'Informar login ou matrícula!'
      ],
      senha: '',
      senhaRules: [
        v => !!v || 'Campo obrigatório!'
      ],
      valid: true
    }
  },
  computed: {
    ...mapState('account', ['status']),
    ...mapState({
      account: state => state.account
    })
  },
  created () {
    this.logout()
    if (this.account.state.mensagem !== '') {
      this.account.state.mensagem = ''
    }
  },
  methods: {
    ...mapActions('account', ['login', 'logout']),
    validate () {
      if (this.$refs.form.validate()) {
        this.snackbar = true
        const { email, senha } = this
        if (email && senha) {
          this.login({ email, senha })
        }
      }
    }
  }
}
</script>

<style>
.v-alert.v-alert {
  border-radius: 30px !important;
}

.v-list__tile__title{
  font-size: 20px !important;
  font-weight: 400;
}

.caixaLogin {
  margin-top: 100px;
}
</style>
