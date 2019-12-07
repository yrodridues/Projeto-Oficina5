import { authHeader } from '../_helpers'
import { userService, config } from '.'

export const projetoService = {
  getAllUsuario,
  getUsuarioId,
  getAllMensagem,
  getMensagemId,
  getMensagemUsuario,
  registerUsuario,
  registerMensage,
  updateUsuario,
  deleteUsuario: _delete
}

function getAllUsuario () {
  const requestOptions = {
    method: 'GET',
    headers: authHeader()
  }
  return fetch(`${config.apiUrl}/Servico/ObterTodosUsuarios`, requestOptions).then(handleResponse)
}

function getUsuarioId (id) {
  const requestOptions = {
    method: 'GET',
    headers: authHeader()
  }
  return fetch(`${config.apiUrl}/Servico/ObterUsuarioPorId/${id}`, requestOptions).then(handleResponse)
}

function getAllMensagem () {
  const requestOptions = {
    method: 'GET',
    headers: authHeader()
  }
  return fetch(`${config.apiUrl}/Servico/ObterTodasMensagens`, requestOptions).then(handleResponse)
}

function getMensagemId (idPost) {
  const requestOptions = {
    method: 'GET',
    headers: authHeader()
  }
  return fetch(`${config.apiUrl}/Servico/ObterMensagemPorIdPost/${idPost}`, requestOptions).then(handleResponse)
}

function getMensagemUsuario (idUser) {
  const requestOptions = {
    method: 'GET',
    headers: authHeader()
  }
  return fetch(`${config.apiUrl}/Servico/ObterPostPorIdUsuario/${idUser}`, requestOptions).then(handleResponse)
}

function registerUsuario (usuario) {
  const requestOptions = {
    method: 'POST',
    headers: { ...authHeader(), 'Content-type': 'application/json' },
    body: JSON.stringify(usuario)
  }
  return fetch(`${config.apiUrl}/Servico/AdicionarUsuario`, requestOptions).then(handleResponse)
}

function registerMensage (mensage) {
  const requestOptions = {
    method: 'POST',
    headers: { ...authHeader(), 'Content-type': 'application/json' },
    body: JSON.stringify(mensage)
  }
  return fetch(`${config.apiUrl}/Servico/EnviarMensagem`, requestOptions).then(handleResponse)
}

function updateUsuario (usuario) {
  const requestOptions = {
    method: 'PUT',
    headers: { ...authHeader(), 'Content-Type': 'application/json' },
    body: JSON.stringify(usuario)
  }
  return fetch(`${config.apiUrl}/Servico/AtualizarUsuario/${usuario.id}`, requestOptions).then(handleResponse)
}

function _delete (id) {
  const requestOptions = {
    method: 'DELETE',
    headers: authHeader()
  }
  return fetch(`${config.apiUrl}/Servico/DeletarUsuario/${id}`, requestOptions).then(handleResponse)
}

function handleResponse (response) {
  return response.text().then(text => {
    const data = text && JSON.parse(text)
    if (!response.ok) {
      if (response.status === 401) {
        userService.logout()
        location.reload(true)
      }
      const error = (data && data.message) || response.statusText
      return Promise.reject(error)
    }
    return data
  })
}
