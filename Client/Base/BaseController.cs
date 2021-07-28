using Client.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Client.Enums.Enums;

namespace Client.Base
{
    public class BaseController<TEntity, TRepository, TId> : Controller
            where TEntity : class
            where TRepository : IRepository<TEntity, TId>
    {
        private readonly TRepository repository;

        public void Alert(string title, string message, NotificationType notificationType)
        {
            //Swal.fire({icon: 'error', title: 'Oops...', text: 'Something went wrong!'})
            //Swal.fire('The Internet?','That thing is still around?','question')
            var msg = "<script language='javascript'>Swal.fire('" + title.ToUpper() + "', '" + message + "','" + notificationType + "')" + "</script>";
            TempData["notification"] = msg;
        }
        public void Message(string message, NotificationType notifyType)
        {
            TempData["Notification2"] = message;

            switch (notifyType)
            {
                case NotificationType.success:
                    TempData["NotificationCSS"] = "alert-box success";
                    break;
                case NotificationType.error:
                    TempData["NotificationCSS"] = "alert-box errors";
                    break;
                case NotificationType.warning:
                    TempData["NotificationCSS"] = "alert-box warning";
                    break;

                case NotificationType.info:
                    TempData["NotificationCSS"] = "alert-box notice";
                    break;
            }
        }

        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var result = await repository.Get();
            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> Get(TId id)
        {
            var result = await repository.Get(id);
            return Json(result);
        }

        [HttpPost]
        public JsonResult Post(TEntity entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }

        [HttpPut]
        public JsonResult Put(TId id, TEntity entity)
        {
            var result = repository.Put(id, entity);
            return Json(result);
        }

        [HttpDelete]
        public JsonResult Delete(TId id)
        {
            var result = repository.Delete(id);
            return Json(result);
        }
    }
}
