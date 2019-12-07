<template>
<v-container
      fill-height
      fluid
      grid-list-xl>
      <v-layout
        row
        wrap>
        <v-flex
          xl12
          lg12
          md12
          sm12
          xs9>
          <material-card
            color="primary"
            title="Cadastrar Usuario">
            <v-form
              ref="form"
              v-model="valid"
              lazy-validation>
              <strong>Informe o Id do Usuario: </strong>
              <v-text-field
                v-model="usuario.userId"
                required/>
            <strong>Informe o Titulo: </strong>
              <v-text-field
                v-model="usuario.title"
                required/>
            <strong>Informe o Corpo: </strong>
              <v-text-field
                v-model="usuario.body"
                required/>
            </v-form>
            <v-btn
              :disable="!valid"
              color="success"
              @click="handleSubmit">
              <v-icon left>
                mdi-plus-circle
              </v-icon>
              Cadastrar
            </v-btn>
          </material-card>
           <material-card
            color="primary"
            title="Gerenciar Usuarios">
            <v-card-title>
              <v-text-field
                v-model="search"
                append-icon="mdi-magnify"
                label="Pesquisar..."
                single-line
                hide-details />
            </v-card-title>
            <v-data-table
              :headers="headers"
              :items="projetos"
              :search="search"
              :pagination.sync="pagination"
              :rows-per-page-text="textoPaginacao"
              hide-actions
              class="elevation-1">
              <template v-slot:items="props">
                <td>{{ props.item.userId }}</td>
                <td>{{ props.item.title }}</td>
                <td>{{ props.item.body }}</td>
                <td class="text-xs-center">
                  <v-btn color="info">
                    <v-icon left>
                      mdi-pencil-circle
                    </v-icon>
                    Editar
                  </v-btn>
                </td>
                <td class="text-xs-center">
                  <v-btn color="error">
                      <v-icon left>
                      mdi-delete-circle
                    </v-icon>
                    Excluir
                  </v-btn>
                </td>
              </template>
              <template v-slot:no-data>
                <v-alert
                  :value="true"
                  color="error"
                  icon="mdi-alert">
                  Não há usuarios cadastrados! :(
                </v-alert>
              </template>
              <template v-slot:no-results>
                <v-alert
                  :value="true"
                  color="error"
                  icon="mdi-alert">
                  Você pesquisou por "{{ search }}", porém nenhum resultado foi encontrado.
                </v-alert>
              </template>
            </v-data-table>
            <div class="text-xs-center pt-2">
              <v-pagination
                v-model="pagination.page"
                :length="pages"
                :total-visible="5"
                circle />
            </div>
          </material-card>
        </v-flex>
      </v-layout>
    </v-container>
</template>
<script>
import { mapState, mapActions } from 'vuex'
export default {
  data () {
    return {
      textoPaginacao: 'Exibir',
      textoCadastro: 'Cadastrado com sucesso!',
      modalEdit: false,
      modalDelete: false,
      timeout: 4000,
      valid: true,
      snackbar: false,
      snackbarError: false,
      snackbarDeleteError: false,
      pagination: {
        descending: false,
        page: 1,
        rowsPerPage: 5,
        totalItems: 0
      },
      search: '',
      id: '',
      userId: '',
      title: '',
      body: '',
      usuario: {
        id: '',
        userId: '',
        title: '',
        body: ''
      },
      headers: [
        { text: 'UserId', align: 'left', value: 'userId' },
        { text: 'Title', align: 'left', sortable: false },
        { text: 'Body', align: 'left', sortable: false },
        { text: 'Editar', align: 'center', sortable: false },
        { text: 'Excluir', align: 'center', sortable: false }
      ]
    }
  },
  computed:{
      ...mapState({
          projetos: state => state.projetos.all.items
      }),
      pages () {
      try {
        // eslint-disable-next-line vue/no-side-effects-in-computed-properties
        this.pagination.totalItems = this.projetos.length
        if (this.pagination.totalItems !== undefined) {
          if (this.pagination.rowsPerPage == null || this.pagination.totalItems === null) {
            return 0
          }
          return Math.ceil(this.pagination.totalItems / this.pagination.rowsPerPage)
        }
      } catch (e) {
      }
    }
  },
  created () {
      this.getAllUsuario()
  },
  methods: {
      ...mapActions('projetos', {
          getAllUsuario: 'getAllUsuario',
            getUsuarioId: 'getUsuarioId',
            getAllMensagem: 'getAllMensagem',
            getMensagemId: 'getMensagemId',
            getMensagemUsuario: 'getMensagemUsuario',
            registerUsuario: 'registerUsuario',
            registerMensage: 'registerMensage',
            updateUsuario: 'updateUsuario',
            deleteUsuario: 'deleteUsuario'
      }),
    handleSubmit () {
        this.snackbar = true
        this.registerUsuario(this.usuario)
        .then(
            this.snackbar = true,
            this.$refs.form.reset()
        )
    }
  }
}
</script>
