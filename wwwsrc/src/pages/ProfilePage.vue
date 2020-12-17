<template>
  <div class="about text-center">
    <h1>Welcome {{ profile.name }}</h1>
    <img class="rounded" :src="profile.picture" alt="" />
    <p>{{ profile.email }}</p>
    <h5>Add Blog</h5>
    <form @submit.prevent="create(state.newBlog)">
      <div class="form-group">
        <label for="blog-title">Blog Title</label>
        <input type="text"
               class="form-control"
               id="blog-title"
               aria-describedby="emailHelp"
               placeholder="Enter Title..."
               v-model="state.newBlog.title"
        >
      </div>
      <div class="form-group">
        <label for="description">Description</label>
        <input type="text" class="form-control" id="description" placeholder="Enter description" v-model="state.newBlog.body">
      </div>
      <div class="form-check">
        <input type="checkbox" class="form-check-input" id="isPublished" v-model="state.newBlog.isPublished">
        <label class="form-check-label" for="isPublished">Published?</label>
      </div>
      <button type="submit" class="btn btn-primary">
        Submit
      </button>
    </form>
    <blog v-for="blog in blogs" :blog-prop="blog" :key="blog.id" />
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { blogsService } from '../services/BlogsService'
import { profileService } from '../services/ProfileService'
export default {
  name: 'Profile',
  setup() {
    onMounted(async() => {
      if (!AppState.profile.id) {
        await profileService.getProfile()
      }
      await blogsService.getMyBlogs()
    })
    const state = reactive({
      newBlog: {
        title: '',
        body: '',
        isPublished: false
      }
    })
    return {
      state,
      create(newBlog) {
        // state.newBlog either or
        blogsService.create(newBlog)
      },
      profile: computed(() => AppState.profile),
      blogs: computed(() => AppState.blogs)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
