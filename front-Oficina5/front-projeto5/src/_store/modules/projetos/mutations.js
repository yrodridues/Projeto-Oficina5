// import { router } from '../../../_helpers'

export default {

  getAllRequest (state) {
    state.all = { items: [] }
  },
  getAllSuccess (state, projeto) {
    state.all = { items: projeto }
  },
  getAllFailure (state, error) {
    state.all = { error }
  },
  registerRequest (state, projeto) {
    state.status = { registering: true }
  },
  registerSuccess (state, projeto) {
    state.status = { }
  },
  registerFailure (state, error) {
    state.status = { }
  },

  deleteRequest (state, id) {
    state.all.items = state.all.items.map(usuario =>
      usuario.id === id
        ? { ...usuario, deleting: true }
        : usuario
    )
  },
  deleteSuccess (state, id) {
    state.all.items = state.all.items.filter(usuario =>
      usuario.id !== id)
  },
  deleteFailure (state, { id, error }) {
    state.all.items = state.items.map(usuario => {
      if (usuario.id === id) {
        const { deleting, ...usuarioCopy } = usuario
        return { ...usuarioCopy, deleteError: error }
      }
      return usuario
    })
  }
}
