using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taller_be.Models;

namespace taller_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIListasController : ControllerBase
    {
        private readonly DBTallerVUE _context;

        public APIListasController(DBTallerVUE context)
        {
            _context = context;
        }

        // GET: api/APIListas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskList>>> GetTaskLists()
        {
            return await _context.TaskLists.ToListAsync();
        }

        // GET: api/APIListas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskList>> GetTaskList(decimal id)
        {
            var taskList = await _context.TaskLists.FindAsync(id);

            if (taskList == null)
            {
                return NotFound();
            }

            return taskList;
        }

        // PUT: api/APIListas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskList(decimal id, TaskList taskList)
        {
            if (id != taskList.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/APIListas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaskList>> PostTaskList([FromBody]TaskList taskList)
        {
            _context.TaskLists.Add(taskList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskList", new { id = taskList.Id }, taskList);
        }

        // DELETE: api/APIListas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskList>> DeleteTaskList(decimal id)
        {
            var taskList = await _context.TaskLists.FindAsync(id);
            if (taskList == null)
            {
                return NotFound();
            }

            _context.TaskLists.Remove(taskList);
            await _context.SaveChangesAsync();

            return taskList;
        }

        private bool TaskListExists(decimal id)
        {
            return _context.TaskLists.Any(e => e.Id == id);
        }
    }
}
