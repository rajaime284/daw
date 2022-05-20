<template>
  <div>
    <Mislistas v-bind:titulo="$t('app.titulo')"/>
    
  </div>
  
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import Mislistas from '@/components/Mislistas.vue'; // @ is an alias to /src

@Component({
   components: {
      Mislistas,
   },
})

export default class Home extends Vue {}
</script>

