using Raven.Abstractions.Data;
using SignalrWebFormDemo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalrWebFormDemo
{
    public class RavenObserver : IObserver<DocumentChangeNotification>
    {
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
            //ToDo:handle exception
        }

        public void OnNext(DocumentChangeNotification documentChangeNotification)
        {
            if (documentChangeNotification.Type == DocumentChangeTypes.Put)//new document inserted
            {
                RavenModel model;
                using (var session = Global.store.OpenSession())
                {
                    model = session.Load<RavenModel>(documentChangeNotification.Id);//get document by id
                }

                new SignalrWebFormDemo.Hubs.RavenHub().Send(model.name, model.message);//notify clients
            }
        }
    }
}