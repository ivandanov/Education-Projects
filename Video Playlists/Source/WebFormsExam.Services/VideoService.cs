using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsExam.Data.Repostiories;
using WebFormsExam.Models;
using WebFormsExam.Services.Contracts;

namespace WebFormsExam.Services
{
    public class VideoService : IVideoService
    {
        private IRepository<Video> videos;

        public VideoService(IRepository<Video> videos)
        {
            this.videos = videos;
        }

        public void DeleteVideoById(int id)
        {
            var video = this.videos.GetById(id);
            if(video == null)
            {
                return;
            }

            this.videos.Delete(video);
            this.videos.SaveChanges();
        }
    }
}
