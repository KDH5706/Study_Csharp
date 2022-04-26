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
            

            anounce.setNoticeMsg("첫 번째 공지입니다.");
        }
    }
}



/* 
 * 학교 클래스의 속성 : 이름, 
 * 
 * 
 * 교직원 L명, 학생 M명, 공지사항 N개
 * 확장성을 위해 아르바이트 or 외부강사 추가 고려
 * 공지사항 알림 신청 or 취소
 * 신규 공지사항이 등록 될 때 마다 알림 신청 인원들에게 자동으로 공지 알림
 * 공지사항은 교직원용, 학생용, 교직원+학생(일반)용으로 구분하여 등록
 * 
 */