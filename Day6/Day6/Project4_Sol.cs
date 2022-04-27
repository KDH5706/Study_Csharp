using System;
using System.Collections;

namespace Ex4ForClass
{
    public interface Observer   //구독자
    {
        public void update(string msg);             //주체의 상태가 바뀌었을때 호출됨
    }

    public interface Subject    //주체
    {
        public void registerObserver(Observer o);   //옵저버 등록
        public void removeObserver(Observer o);     //옵저버 삭제
        public void notifyObservers();              //옵저버에게 업데이트 알림
    }

    class AnnouncementForStudent : Subject
    {
        private ArrayList students;     //Add(), Remove() 메서드 사용 가능한 ArrayList(List컬렉션과는 다르게 여러 자료형을 담을 수 있다.)
        private string noticeMsg;

        public AnnouncementForStudent()
        {
            this.students = new ArrayList();
        }

        public void registerObserver(Observer o)        //옵저버 등록(인터페이스에서 상속 받은 메서드)
        {
            this.students.Add(o);
        }

        public void removeObserver(Observer o)          //옵저버 삭제(인터페이스에서 상속 받은 메서드)
        {
            this.students.Remove(o);
        }

        public void notifyObservers()                   //옵저버에게 업데이트 알림(인터페이스에서 상속 받은 메서드)
        {
            foreach (Student s in students)
                s.update(this.noticeMsg);
        }

        public void setNoticeMsg(string newNoticeMsg)
        {
            this.noticeMsg = newNoticeMsg;
            this.notifyObservers();
        }
    }

    class AnnouncementForEmployee : Subject
    {
        void Subject.registerObserver(Observer o)        //옵저버 등록(인터페이스에서 상속 받은 메서드)
        {
        }

        void Subject.removeObserver(Observer o)          //옵저버 삭제(인터페이스에서 상속 받은 메서드)
        {
        }
        void Subject.notifyObservers()                   //옵저버에게 업데이트 알림(인터페이스에서 상속 받은 메서드)
        {
        }
    }

    class Student : Observer
    {
        private string noticeMsg;
        private AnnouncementForStudent announce;
        private string stuName;

        public Student(string stuName)
        {
            this.stuName = stuName;
        }

        public void update(string newNoticeMsg)     //인터페이스에서 상속받은 메서드이므로 무조건 정의해야함
        {
            this.noticeMsg = newNoticeMsg;
            display();
        }

        public void display()
        {
            Console.WriteLine($"{this.stuName} 학생을 위한 새로운 공지 : {this.noticeMsg}");
        }

        public void registerAnnouncement(AnnouncementForStudent announce)
        {
            this.announce = announce;
        }
    }

    class Employee : Observer
    {
        public void update(string msg)     //인터페이스에서 상속받은 메서드이므로 무조건 정의해야함
        {
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            AnnouncementForStudent anounceForStu = new AnnouncementForStudent();
            Student student1 = new Student("홍길동");
            anounceForStu.registerObserver(student1);

            Student student2 = new Student("강남길");
            anounceForStu.registerObserver(student2);

            Student student3 = new Student("이문수");
            anounceForStu.registerObserver(student3);

            anounceForStu.setNoticeMsg("1 번째 공지 입니다.");
            Console.WriteLine();

            anounceForStu.setNoticeMsg("2 번째 공지 입니다.");
            Console.WriteLine();

            anounceForStu.setNoticeMsg("3 번째 공지 입니다.");
            Console.WriteLine();

            anounceForStu.removeObserver(student2);

            anounceForStu.setNoticeMsg("4 번째 공지 입니다.");
            Console.WriteLine();

            anounceForStu.removeObserver(student1);

            anounceForStu.setNoticeMsg("5 번째 공지 입니다.");
            Console.WriteLine();
        }
    }
}
