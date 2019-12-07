export function authHeader () {
  // return authorization header with jwt token
  let user = JSON.parse(localStorage.getItem('usuario'))
  if (user && user.value.token) {
    return { 'Authorization': 'Bearer ' + user.value.token }
  } else {
    return {}
  }
}
