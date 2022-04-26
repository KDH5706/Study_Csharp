using System;
using System.Collections;

namespace Ex4ForClass
{
    class Announcement
    {
        private Student student;
        private string noticeMsg;

        public Announcement(Student student)
        {
            this.student = student;
        }

        public void norifyStudents()
        {
            student.update(this.noticeMsg);
        }

        public void setNoticeMsg(string newNoticeMsg)
        {
            this.noticeMsg = newNoticeMsg;
            this.norifyStudents();
        }
    }

    class Student
    {
        private string noticeMsg;
        private Announcement announce;
        private string stuName;

        public Student(string stuName)
        {
            this.stuName = stuName;
        }

        public void update(string newNoticeMsg)
        {
            this.noticeMsg = newNoticeMsg;
            display();
        }

        public void registerAnnouncement(Announcement announce)
        {
            this.announce = announce;
        }

        public void display()
        {
            Console.WriteLine($"{this.stuName} 학생을 위한 새로운 공지 : {this.noticeMsg}");
        }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            Student student = new Student("홍길동");
            Announcement anounce = new Announcement(student);
            student.registerAnnouncement(anounce);


            anounce.setNoticeMsg("첫 번째 공지 입니다.");
        }
    }
}
