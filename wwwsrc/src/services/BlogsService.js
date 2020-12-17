import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { AppState } from '../AppState'

class BlogsService {
  async getPublicBlogs() {
    try {
      const res = await api.get('api/blogs')
      logger.log(res.data)
      AppState.blogs = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async create(banana) {
    try {
      await api.post('api/blogs', banana)
      this.getMyBlogs()
    } catch (error) {
      logger.log(error)
    }
  }

  async getMyBlogs() {
    try {
      logger.log(AppState.profile)
      const res = await api(`profile/${AppState.profile.id}/blogs`)
      AppState.blogs = res.data
      // NOTE dont forget to add your js doc types in the appstate
      // AppState.blogs = res.data.map(e => new Blog(e.title, e.body))
      // this now has intellisense on 'b' AppState.blogs.forEach(b=> b.)
    } catch (error) {
      logger.error(error)
    }
  }
}

export const blogsService = new BlogsService()
