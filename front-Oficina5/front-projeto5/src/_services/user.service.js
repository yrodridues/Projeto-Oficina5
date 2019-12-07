import { authHeader } from '../_helpers'
import { config } from '.'

export const userService = {
  login,
  logout,
  register,
  getAll,
  getById,
  update,
  delete: _delete
}

function login (login, senha) {
  let sistema = 'Habitação'
  const requestOptions = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ login, senha, sistema })
  }
  return fetch(`${config.apiUrlUsuario}/token`, requestOptions)
    .then(handleResponse)
    .then(user => {
      if (user.value) {
        localStorage.setItem('usuario', JSON.stringify(user))
      }
      console.log(user)
      return user
    })
}

function logout () {
  // remove user from local storage to log user out
  localStorage.removeItem('usuario')
}

function register (user) {
  const requestOptions = {
    method: 'POST',
    headers: { ...authHeader(), 'Content-Type': 'application/json' },
    // headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(user)
  }
  return fetch(`${config.apiUrl}/usuario`, requestOptions).then(handleResponse)
}

function getAll () {
  const requestOptions = {
    method: 'GET',
    headers: authHeader()
  }
  return fetch(`${config.apiUrl}/usuario`, requestOptions).then(handleResponse)
}

function getById (id) {
  const requestOptions = {
    method: 'GET',
    headers: authHeader()
  }
  return fetch(`${config.apiUrl}/usuario/${id}`, requestOptions).then(handleResponse)
}

function update (user) {
  const requestOptions = {
    method: 'PUT',
    headers: { ...authHeader(), 'Content-Type': 'application/json' },
    body: JSON.stringify(user)
  }
  return fetch(`${config.apiUrl}/usuario/${user.id}`, requestOptions).then(handleResponse)
}

function _delete (id) {
  const requestOptions = {
    method: 'DELETE',
    headers: authHeader()
  }
  return fetch(`${config.apiUrl}/usuario/${id}`, requestOptions).then(handleResponse)
}

function handleResponse (response) {
  return response.text().then(text => {
    const data = text && JSON.parse(text)
    if (!response.ok) {
      if (response.status === 401) {
        logout()
        location.reload(true)
      }
      const error = (data && data.message) || response.statusText
      return Promise.reject(error)
    }
    return data
  })
}
