using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BlogPageMVC.Models;
namespace BlogPageMVC.ViewModel
{
    public class PostViewModel : ViewModelBase
    {
        public PostViewModel() { }

        public PostViewModel(tbPost post)
        {
            // tên trang = tên bài viết
            PageTitle = post.Tittle;

            this.id = post.id;
            Tittle = post.Tittle;
            Url = post.Url;
            Content = post.Content;
            ShortContent = post.ShortContent;

            // catch null
            Views = post.Views ?? 0;
            Shares = post.Shares ?? 0;
            DatePublish = post.DateCreate ?? DateTime.Now;
            Visiable = post.Visiable ?? true;

            ListTag = getListTag(post.id);

            Category = getCategory(post.id);
        }

        // get list tag of post with post_id
        private List<tbTag> getListTag(int _id)
        {
            var results = db.tbTags.Where(p => p.tbPost_Tag.Any(c => c.Post_id == _id)).ToList();
            return results;
        }

        // get category of post with post_id
        private tbCategory getCategory(int _id)
        {
            var results = db.tbCategories.Where(p => p.tbPost_Category.Any(c => c.Post_id == _id)).FirstOrDefault();
            return results;
        }


        [DisplayName("Mã bài viết")]
        public int id { get; }

        [DisplayName("Tên bài viết")]
        public string Tittle { get; set; }

        [DisplayName("Đường dẫn")]
        public string Url { get; set; }

        [DisplayName("Nội dung bài viết")]
        public string Content { get; set; }

        [DisplayName("Nội dung hiển thị")]
        public string ShortContent { get; set; }

        [DisplayName("Lượt xem")]
        public int Views { get; set; }

        [DisplayName("Lượt chia sẻ")]
        public int Shares { get; set; }

        [DisplayName("Ngày Đăng")]
        public DateTime DatePublish { get; set; }

        [DisplayName("Trạng thái")]
        public bool Visiable { get; set; }

        [DisplayName("Danh sách tag")]
        public List<tbTag> ListTag { get; set; }

        [DisplayName("Mục bài viết")]
        public tbCategory Category { get; set; }


    }
}