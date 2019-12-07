import { projetoService } from '../../../_services'
// import { router} from '../../../_helpers'

export default {
  getAllUsuario ({ commit }) {
    commit('getAllRequest')
    projetoService.getAllUsuario()
      .then(
        beneficio => commit('getAllSuccess', beneficio),
        error => commit('getAllFailure', error)
      )
  },
  getUsuarioId ({ commit }) {
    commit('getAllRequest')
    projetoService.getUsuarioId()
      .then(
        beneficio => commit('getAllSuccess', beneficio),
        error => commit('getAllFailure', error)
      )
  },
  getAllMensagem ({ commit }) {
    commit('getAllRequest')
    projetoService.getAllMensagem()
      .then(
        beneficio => commit('getAllSuccess', beneficio),
        error => commit('getAllFailure', error)
      )
  },
  getMensagemId ({ commit }) {
    commit('getAllRequest')
    projetoService.getMensagemId()
      .then(
        beneficio => commit('getAllSuccess', beneficio),
        error => commit('getAllFailure', error)
      )
  },
  getMensagemUsuario ({ commit }) {
    commit('getAllRequest')
    projetoService.getMensagemUsuario()
      .then(
        beneficio => commit('getAllSuccess', beneficio),
        error => commit('getAllFailure', error)
      )
  },
  updateUsuario ({ dispatch, commit }, usuario) {
    commit('registerRequest', usuario)
    projetoService.updateUsuario(usuario)
      .then(
        usuario => {
          commit('registerSuccess', usuario)
          setTimeout(() => {
            dispatch('alert/success', 'Registration Successful', { root: true })
            commit('getAllRequest')
            projetoService.getAllUsuario()
              .then(
                usuario => commit('getAllSuccess', usuario),
                error => commit('getAllFailure', error)
              )
          })
        },
        error => {
          commit('registerFailure', error)
          dispatch('alert/error', error, { root: true })
        }
      )
  },
  registerUsuario ({ dispatch, commit }, usuario) {
    commit('registerRequest', usuario)
    projetoService.registerUsuario(usuario)
      .then(
        usuario => {
          commit('registerSuccess', usuario)
          setTimeout(() => {
            dispatch('alert/success', 'Registration Successful', { root: true })
            commit('getAllRequest')
            projetoService.getAllUsuario()
              .then(
                usuario => commit('getAllSuccess', usuario),
                error => commit('getAllFailure', error)
              )
          })
        },
        error => {
          commit('registerFailure', error)
          dispatch('alert/error', error, { root: true })
        }
      )
  },
  registerMensage ({ dispatch, commit }, mensage) {
    commit('registerRequest', mensage)
    projetoService.registerMensage(mensage)
      .then(
        mensage => {
          commit('registerSuccess', mensage)
          setTimeout(() => {
            dispatch('alert/success', 'Registration Successful', { root: true })
            commit('getAllRequest')
            projetoService.getAllMensagem()
              .then(
                mensage => commit('getAllSuccess', mensage),
                error => commit('getAllFailure', error)
              )
          })
        },
        error => {
          commit('registerFailure', error)
          dispatch('alert/error', error, { root: true })
        }
      )
  },
  deleteUsuario ({ commit }, id) {
    commit('deleteRequest', id)
    projetoService.delete(id)
      .then(
        usuario => commit('deleteSuccess', id),
        error => commit('deleteFailure', { id, error: error.toString() })
      )
  }
}
