<template>
  <div class="blog card p-2 shadow-lg border border-primary rounded">
    <h1>
      {{ blog.title }}
    </h1>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'Blog',
  props: ['blogProp'],
  setup(props) {
    return {
      blog: computed(() => props.blogProp)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
