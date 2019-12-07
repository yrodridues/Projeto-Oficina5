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
            height="350"
            src="../img/MorarBem.png"/>
          <v-spacer style="padding-top: 50px;"/>
          <template>
            <v-container
              grid-list-md
              text-center>
              <v-layout wrap>
                <v-hover v-slot:default="{ hover }">
                  <v-card
                    :elevation="hover ? 12 : 2"
                    :flat="flat"
                    :loading="loading"
                    :outlined="outlined"
                    :raised="raised"
                    :width="width"
                    :height="height"
                    class="mx-auto"
                    max-width="350">
                    <v-img
                      v-if="media"
                      class="white--text"
                      height="200px"
                      src="../img/MorarBem1.png"/>
                    <v-card-text style="text-align: justify">
                      O programa é uma parceria do Município com a Caixa Econômica Federal, Sinduscon, CRECI-MG e empreendedores.
                      O programa atenderá famílias classificadas na faixa 1,5 e faixa 2 do Minha Casa Minha Vida, com renda predefinida de R$1.500,00 até R$ 4.000,00.
                      A expectativa é que o Município participe da contratação de 3 mil unidades, com previsão de atender aproximadamente 1.000 famílias por ano.
                      Com o objetivo de reduzir o déficit habitacional, oferecendo diferenciadas condições aos cidadãos que têm interesse em adquirir o seu primeiro imóvel,
                      além de gerar emprego e renda para o município, o Programa Municipal de Habitação Morar Bem foi lançado pela Prefeitura Municipal,
                      através da Secretaria de Desenvolvimento Social (SMDS) na manhã dessa terça-feira (09).
                    </v-card-text>
                  </v-card>
                </v-hover>
                <v-hover v-slot:default="{ hover }">
                  <v-card
                    :elevation="hover ? 12 : 2"
                    :flat="flat"
                    :loading="loading"
                    :outlined="outlined"
                    :raised="raised"
                    :width="width"
                    :height="height"
                    class="mx-auto"
                    max-width="350">
                    <v-img
                      v-if="media"
                      class="white--text"
                      height="200px"
                      src="../img/MinhaCasaVida2.png"/>
                    <v-card-text style="text-align: justify">
                      Minha Casa Minha Vida é uma iniciativa do Governo Federal que oferece condições atrativas para o financiamento de moradias
                      nas áreas urbanas para famílias de baixa renda. Em parceria com estados, municípios, empresas e entidades sem fins lucrativos,
                      o programa vem mudando a vida de milhares de famílias brasileiras. É oportunidade para quem precisa e mais desenvolvimento para o Brasil.
                      <v-spacer/>
                      <strong
                        class="primary--text"
                        style="font-size: 16px !important">Menor taxa de juros do mercado:</strong><v-spacer/>
                      O Programa do Governo Federal oferece condições de pagamento e taxas de juros de acordo com a renda da sua família.
                      <v-spacer/>
                      <strong
                        class="primary--text"
                        style="font-size: 16px !important">Financiamentos de moradias em áreas urbanas ou rurais:</strong><v-spacer/>
                      Você pode financiar a compra de imóvel novo em área urbana ou ainda a construção e reforma de moradias em área urbana e rural.
                      <v-spacer/>
                      <strong
                        class="primary--text"
                        style="font-size: 16px !important">Atendimento especializado:</strong><v-spacer/>
                      Locais de atendimento específicos, de acordo com cada tipo de financiamento.
                      <v-spacer/>
                      <strong
                        class="primary--text"
                        style="font-size: 16px !important">Programa Caixa de Olho na Qualidade:</strong><v-spacer/>
                      O canal exclusivo para esclarecer dúvidas e registrar eventuais problemas em sua casa e ajudar você a cuidar do seu patrimônio - 08007216268.
                    </v-card-text>
                  </v-card>
                </v-hover>
                <v-hover v-slot:default="{ hover }">
                  <v-card
                    :elevation="hover ? 12 : 2"
                    :flat="flat"
                    :loading="loading"
                    :outlined="outlined"
                    :raised="raised"
                    :width="width"
                    :height="height"
                    class="mx-auto"
                    max-width="350">
                    <v-img
                      v-if="media"
                      class="white--text"
                      height="200px"
                      src="../img/MinhaCasaVida.jpg"/>
                    <v-card-text style="text-align: justify">
                      Nesta modalidade, existem quatro faixas de renda contempladas. São elas:
                      <v-spacer/>
                      <strong
                        class="primary--text"
                        style="font-size: 16px !important">Famílias com renda de até R$ 1.800,00:</strong>
                      Faixa 1 - A Caixa oferece várias vantagens para a sua família.
                      Conte com um financiamento de até 120 meses, com prestações mensais que variam de R$ 80,00 a R$ 270,00,
                      conforme a renda bruta familiar. A garantia para o financiamento é o imóvel que você vai adquirir.
                      Assim, fica muito mais fácil realizar o sonho da casa própria.
                      <v-spacer/>
                      <strong
                        class="primary--text"
                        style="font-size: 16px !important">Famílias com renda de até R$ 2.600,00:</strong>
                      Faixa 1,5: Você pode adquirir um imóvel cujo empreendimento é financiado pela Caixa
                      com taxas de juros de apenas 5% ao ano e até 30 anos para pagar e subsídios de até 47,5 mil reais.
                      <v-spacer/>
                      <strong
                        class="primary--text"
                        style="font-size: 16px !important">Famílias com renda de até R$ 4.000,00:</strong>
                      FAIXA 2: Se sua família tem renda bruta de até R$ 4.000,00,
                      você se encaixa nesta faixa do Programa Minha Casa Minha Vida e pode ter subsídios de até R$ 29.000,00.
                      <v-spacer/>
                      <strong
                        class="primary--text"
                        style="font-size: 16px !important">Famílias com renda de até R$ 7.000,00:</strong>
                      FAIXA 3: Para famílias com renda bruta de até R$ 7.000,00,
                      o Programa Minha Casa Minha Vida oferece taxas de juros diferenciadas em relação ao mercado para você conquistar uma casa própria.
                    </v-card-text>
                  </v-card>
                </v-hover>
              </v-layout>
            </v-container>
          </template>
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
