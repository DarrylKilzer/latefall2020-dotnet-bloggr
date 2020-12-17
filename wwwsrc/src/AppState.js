import { reactive } from 'vue'
// eslint-disable-next-line no-unused-vars
// import Blog from './models/Blog'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  profile: {},
  // /** @type { Blog[] } */
  blogs: []
})
