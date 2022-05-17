import ItemTask from '@/models/ItemTask';
import moment from 'moment';

export default class TaskList {
   id=0;
   nombre="";
   color="#FFFFFF";
   visible=true;
   fecha:moment.Moment=moment();
   tasks:ItemTask[]=[];
}